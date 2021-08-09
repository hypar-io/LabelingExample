// This code was generated by Hypar.
// Edits to this code will be overwritten the next time you run 'hypar init'.
// DO NOT EDIT THIS FILE.

using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Validators;
using Elements.Serialization.JSON;
using Hypar.Functions;
using Hypar.Functions.Execution;
using Hypar.Functions.Execution.AWS;
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace DrawTests
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public  class DrawTestsInputs : S3Args
    
    {
        [Newtonsoft.Json.JsonConstructor]
        
        public DrawTestsInputs(double @xValues, double @yValues, double @textScale, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey):
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<DrawTestsInputs>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @xValues, @yValues, @textScale});
            }
        
            this.XValues = @xValues;
            this.YValues = @yValues;
            this.TextScale = @textScale;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        /// <summary>The number of values in the X direction.</summary>
        [Newtonsoft.Json.JsonProperty("X Values", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1D, 10D)]
        public double XValues { get; set; }
    
        /// <summary>The number of values in the Y direction.</summary>
        [Newtonsoft.Json.JsonProperty("Y Values", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1D, 10D)]
        public double YValues { get; set; }
    
        /// <summary>The scale of the text.</summary>
        [Newtonsoft.Json.JsonProperty("Text Scale", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1D, 100D)]
        public double TextScale { get; set; }
    
    
    }
}