using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CDS.Shared.Exception
{
   public class InvalidEntityQueryException : System.Exception, ISerializable
   {
      public InvalidEntityQueryException()
         : base()
      { 
         // Add implementation (if required)
      }

      public InvalidEntityQueryException(string message)
         : base(message)
      { 
         // Add implemenation (if required)
      }

      public InvalidEntityQueryException(string message, System.Exception inner)
         : base(message, inner)
      { 
         // Add implementation
      }

      protected InvalidEntityQueryException(SerializationInfo info, StreamingContext context)
         : base(info, context)
      { 
         //Add implemenation
      }
   }
}
