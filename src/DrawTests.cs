using Elements;
using Elements.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace DrawTests
{
    public static class DrawTests
    {
        /// <summary>
        /// The DrawTests function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A DrawTestsOutputs instance containing computed results and the model with any new elements.</returns>
        public static DrawTestsOutputs Execute(Dictionary<string, Model> inputModels, DrawTestsInputs input)
        {
            var structure = inputModels["Structure"].AllElementsOfType<ElementInstance>()
                                                    .Where(e => e.BaseDefinition is Beam)
                                                    .GroupBy(e => e.Transform.Origin.Z);

            var model = new Model();
            var down = Vector3.ZAxis.Negate();

            foreach (var beamGroup in structure)
            {
                // We make arrows and texts in groups of beams because otherwise
                // we'd run out of space in our label texture map. Splitting up
                // the text in this way is still no guarantee that you won't 
                // overrun the atlas, so you'll have to adjust for your case.
                var texts = new List<(Vector3 location, Vector3 direction, string text, Color? color)>();
                var arrows = new List<(Vector3, Vector3, double, Color?)>();
                foreach (var beam in beamGroup)
                {
                    // Get some information about the profiles.
                    // This will be used to calculate the width and the
                    // depth of the beam, to position the text tag floating
                    // next to the beam.
                    var profileBounds = new BBox3(((Beam)beam.BaseDefinition).Profile);
                    var height = profileBounds.Max.Y - profileBounds.Min.Y;
                    var width = profileBounds.Max.X - profileBounds.Min.X;

                    // The location of the text is a combination of the 
                    // base definition's curve center, and the element
                    // instance's transform.
                    var t = ((Beam)beam.BaseDefinition).Curve.TransformAt(0.5);
                    t.Concatenate(beam.Transform);
                    var l = ((Beam)beam.BaseDefinition).Curve.Length();
                    var dir = t.XAxis;

                    // Create model text data.
                    var to = t.Origin + t.XAxis * width / 2;
                    texts.Add((to, dir, $"{l.ToString("0.##m")}", Colors.Darkgray));

                    // Create model arrow data.
                    var ao = t.Origin + new Vector3(0, 0, 1.0);
                    arrows.Add((ao, down, 1.0 - height / 2, Colors.Green));
                }
                var modelText = new ModelText(texts, FontSize.PT36, input.TextScale);
                model.AddElement(modelText);
                var modelArrows = new ModelArrows(arrows);
                model.AddElement(modelArrows);
            }

            var output = new DrawTestsOutputs(0)
            {
                Model = model
            };

            return output;
        }
    }
}