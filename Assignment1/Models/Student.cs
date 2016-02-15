namespace Assignment1.Models
{
    /// <summary>
    /// Represents a single student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The social security number or kennitala, 10 digits
        /// Example 0101900109
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// The name of the student
        /// </summary>
        public string Name { get; set; }
    }
}