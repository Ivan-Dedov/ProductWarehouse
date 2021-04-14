using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;

// Taken from:
// https://stackoverflow.com/questions/44370046/how-do-i-serialize-object-to-json-using-json-net-which-contains-an-image-propert

namespace ProductWarehouse.UtilityClasses
{
    /// <summary>
    /// A converter used to convert variables of the Image datatype.
    /// </summary>
    public class ImageConverter : JsonConverter
    {
        /// <summary>
        /// Reads the JSON file containing the Image.
        /// </summary>
        /// <param name="reader">The JsonReader to use.</param>
        /// <param name="objectType">The type of the object to be deserialized.</param>
        /// <param name="existingValue">The value of the object to be deserialized.</param>
        /// <param name="serializer">The JsonSerializer to use.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            var base64 = (string)reader.Value;
            if (base64 is null)
            {
                return null;
            }
            return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
        }

        /// <summary>
        /// Serializes and writes the data about a variable of type Image to the
        /// JSON file.
        /// </summary>
        /// <param name="writer">The JsonWriter to use.</param>
        /// <param name="value">The object to serialize.</param>
        /// <param name="serializer">The JsonSerializer to use.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var image = (Image)value;
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            byte[] imageBytes = ms.ToArray();
            writer.WriteValue(imageBytes);
        }

        /// <summary>
        /// Determines whether the conversion of the object with a specified to Image is possible.
        /// </summary>
        /// <param name="objectType">The type of the object to test.</param>
        /// <returns>true, if the object received is Image; false, otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Image);
        }
    }
}