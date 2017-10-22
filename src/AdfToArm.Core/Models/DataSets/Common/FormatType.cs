using Newtonsoft.Json;

namespace AdfToArm.Core.Models.DataSets.Common
{
    // TODO: validate carefully
    [JsonObject]
    public class FormatType
    {
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type", Required = Required.Always)]
        public FormatTypes Type { get; set; }

        /// <summary>
        /// The character used to separate columns in a file. 
        /// You can consider to use a rare unprintable char that may not likely exists in your data. 
        /// For example, specify "\u0001", which represents Start of Heading (SOH).
        /// 
        /// Only one character is allowed. The default value is comma (',').
        /// </summary>
        [JsonProperty("columnDelimiter", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnDelimiter { get; set; }

        /// <summary>
        /// The character used to separate rows in a file.
        /// 
        /// Only one character is allowed. 
        /// The default value is any of the following values on read: ["\r\n", "\r", "\n"] and "\r\n" on write.
        /// </summary>
        [JsonProperty("rowDelimiter", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RowDelimiter { get; set; }

        /// <summary>
        /// The special character used to escape a column delimiter in the content of input file. 
        /// You cannot specify both escapeChar and quoteChar for a table.
        /// 
        /// Only one character is allowed. No default value. 
        /// <example>if you have comma (',') as the column delimiter but you want to have the comma character in the text (example: "Hello, world"), you can define ‘$’ as the escape character and use string "Hello$, world" in the source.</example>
        /// </summary>
        [JsonProperty("escapeChar", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EscapeChar { get; set; }

        /// <summary>
        /// The character used to quote a string value. 
        /// The column and row delimiters inside the quote characters would be treated as part of the string value. 
        /// This property is applicable to both input and output datasets.
        /// 
        /// You cannot specify both escapeChar and quoteChar for a table.
        /// 
        /// Only one character is allowed. No default value. 
        /// <example>if you have comma (',') as the column delimiter but you want to have comma character in the text (example: ), you can define " (double quote) as the quote character and use the string "Hello, world" in the source.</example>
        /// </summary>
        [JsonProperty("quoteChar", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string QuoteChar { get; set; }

        /// <summary>
        /// One or more characters used to represent a null value.
        /// 
        /// One or more characters. The default values are "\N" and "NULL" on read and "\N" on write.
        /// </summary>
        [JsonProperty("nullValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string NullValue { get; set; }

        /// <summary>
        /// Specify the encoding name.
        /// 
        /// A valid encoding name. see <see cref="Encoding.EncodingName"/> Property. 
        /// <example>windows-1250 or shift_jis</example>
        /// The default value is UTF-8.
        /// </summary>
        [JsonProperty("encodingName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EncodingName { get; set; }

        /// <summary>
        /// Specifies whether to consider the first row as a header. 
        /// For an input dataset, Data Factory reads first row as a header. 
        /// For an output dataset, Data Factory writes first row as a header. 
        /// 
        /// Default value is false
        /// </summary>
        [JsonProperty("firstRowAsHeader", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? FirstRowAsHeader { get; set; }

        /// <summary>
        /// Indicates the number of rows to skip when reading data from input files. 
        /// If both skipLineCount and firstRowAsHeader are specified, the lines are skipped first and then the header information is read from the input file. 
        /// </summary>
        [JsonProperty("skipLineCount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? SkipLineCount { get; set; }

        /// <summary>
        /// Specifies whether to treat null or empty string as a null value when reading data from an input file.
        /// 
        /// Default value is True
        /// </summary>
        [JsonProperty("treatEmptyAsNull", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool? TreatEmptyAsNull { get; set; }

        /// <summary>
        /// Indicate the pattern of data stored in each JSON file. 
        /// Allowed values are: setOfObjects and arrayOfObjects. 
        /// The default value is setOfObjects. 
        /// See JSON file patterns section for details about these patterns.
        /// </summary>
        [JsonProperty("filePattern", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FilePattern { get; set; }

        /// <summary>
        /// If you want to iterate and extract data from the objects inside an array field with the same pattern, specify the JSON path of that array. 
        /// This property is supported only when copying data from JSON files.
        /// </summary>
        [JsonProperty("jsonNodeReference", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string JsonNodeReference { get; set; }

        /// <summary>
        /// If you want to iterate and extract data from the objects inside an array field with the same pattern, specify the JSON path of that array. 
        /// This property is supported only when copying data from JSON files.
        /// </summary>
        [JsonProperty("jsonPathDefinition", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string JsonPathDefinition { get; set; }

        /// <summary>
        /// If you want to iterate and extract data from the objects inside an array field with the same pattern, specify the JSON path of that array. 
        /// This property is supported only when copying data from JSON files.
        /// </summary>
        [JsonProperty("nestingSeparator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public char? NestingSeparator { get; set; }
    }
}
