using System.ComponentModel;

namespace FizzBuzzSample.Models
{

    public class FizzBuzzViewModel
    {
        [DisplayName("Input")]
        public string InputFragment { get; set; }
        
        [DisplayName("Result")]
        public List<string> Results { get; set; }
    }
   
}
