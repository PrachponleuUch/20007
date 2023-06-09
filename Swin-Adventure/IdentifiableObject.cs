using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class IdentifiableObject
    {
       private  List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());
            }
            
        }


        public IdentifiableObject() { }

        public bool AreYou(string id)
        {
            
            
                return _identifiers.Contains(id.ToLower());
            
        }
        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                return string.Empty;
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower()); 
        }
    }
}
