using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public abstract class Node
    {
        public abstract void ResolveNames(LexicalScope ls);
        public abstract void TypeCheck();
        public abstract void GenCode(ref string output);
        public abstract void GenStoreCode( ref string output);
    }

    public class AttributeNumbering{
        public int CurrentAttributeNumber { get; set; }
        

        private static AttributeNumbering instrance;
        private AttributeNumbering()
        {
            CurrentAttributeNumber = -1;
        }

        public int GetCurrentAttributeNumber()
        {
            return CurrentAttributeNumber;
        }

        public int NextCurrentAttributeNumber()
        {
            return CurrentAttributeNumber++;
        }

        public static AttributeNumbering Instance {
            get {
                if (instrance == null)
                    instrance = new AttributeNumbering();
                return instrance;
            }
        }
    }
}
