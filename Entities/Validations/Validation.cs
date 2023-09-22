using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validations
{
    public class Validation
    {
        public string? propertyName { get; set; }
        public string? message { get; set; }
        public List<Validation> validationResponse { get; set; }

        public Validation() 
        {
            validationResponse = new List<Validation>();
        }

        public bool verifyStringIsNull(string value, string propertyName)
        {
            if(string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName)) 
            {
                validationResponse.Add(new Validation
                {
                    message = "Campo obrigatório, favor preencher",
                    propertyName = propertyName,
                });

                return false;
            }

            return true;
        }

        public bool verifyIntIsNullOrEmpty(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                validationResponse.Add(new Validation
                {
                    message = "Campo obrigatório, favor preencher",
                    propertyName = propertyName,
                });

                return false;
            }

            return true;
        }
    }
}
