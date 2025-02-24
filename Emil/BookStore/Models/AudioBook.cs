using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Models
{
    public class AudioBook : DigitalBook
    {
        /// <summary>
        /// The narrator of the audiobook.
        /// </summary>
        public string Narrator { get; set; }

        /// <summary>
        /// The duration of the audiobook.
        /// </summary>
        public TimeSpan Duration { get; set; }
        
        /// <summary>
        /// The audio format of the audiobook.
        /// </summary>
        public string AudioFormat { get; set; }

        /// <summary>
        /// The devices supported by the audiobook.
        /// </summary>
        public string[] SupportedDevices { get; set; }

        /// <summary>
        /// The languages available for the audiobook.
        /// </summary>
        public string[] Languages { get; set; }


        /// <summary>
        /// Constructor for AudioBook.
        /// </summary>
        /// <param name="title">The title of the audiobook.</param>
        /// <param name="author">The author of the audiobook.</param>
        /// <param name="isbn">The ISBN of the audiobook.</param>
        /// <param name="price">The price of the audiobook.</param>
        /// <param name="quantity">The quantity of the audiobook in stock.</param>
        /// <param name="narrator">The narrator of the audiobook.</param>
        /// <param name="duration">The duration of the audiobook.</param>
        /// <param name="audioFormat">The audio format of the audiobook.</param>
        /// <param name="supportedDevices">The devices supported by the audiobook.</param>
        /// <param name="languages">The languages available for the audiobook.</param>
        public AudioBook(string title, string author, string isbn, double price, int quantity, string narrator, TimeSpan duration, string audioFormat, string[] supportedDevices, string[] languages)
            : base(title, author, isbn, price, quantity)
        {
            Narrator = narrator;
            Duration = duration;
            AudioFormat = audioFormat;
            SupportedDevices = supportedDevices;
            Languages = languages;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Narrator: {Narrator}, Duration: {Duration}, AudioFormat: {AudioFormat}, SupportedDevices: {string.Join(", ", SupportedDevices)}, Languages: {string.Join(", ", Languages)}";
        }
    }
}