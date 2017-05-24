using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public abstract class Type : Node
    {
        public bool Compatible(Type other)
        {
            return Equal(other);
        }

        public abstract bool Equal(Type other);
    }

    public class IntType : Type
    {
        public IntType()
        {

        }

        public override void ResolveNames(LexicalScope ls)
        {

        }

        public override void TypeCheck()
        {

        }

        public override bool Equal(Type type)
        {
            return ((IntType)type) != null;
        }

        public override void GenCode(ref string output)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(ref string output)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolType : Type
    {
        public BoolType()
        {
                
        }

        public override bool Equal(Type type)
        {
            return ((BoolType)type) != null;
        }

        public override void GenCode(ref string output)
        {
            
        }

        public override void GenStoreCode(ref string output)
        {
           
        }

        public override void ResolveNames(LexicalScope ls)
        {
            
        }

        public override void TypeCheck()
        {
            
        }
    }
}