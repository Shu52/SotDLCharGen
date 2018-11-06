using System.ComponentModel.DataAnnotations;

namespace SotDLCharGen.ViewModels
{
    public class HumanAbilitiesViewModel
    {

        public int strength { get; set; }

        public int agility { get; set; }

        public int intellect { get; set; }

        public int will { get; set; }

        [Range(42,24,ErrorMessage = "The sum of all values must be 42")]
        public int AllValues 
        {
            get
            {
                return strength + agility + intellect + will;
            }
        }
        
    }
}
