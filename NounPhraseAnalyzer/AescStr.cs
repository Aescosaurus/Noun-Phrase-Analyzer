using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NounPhraseAnalyzer
{
    /// <summary>
    ///     I have to make my own string cuz the C# one is
    ///      stupid and won't let me edit individual chars.
    /// </summary>
    class AescStr
    {
        List<char> characters = new List<char>();
        // 
        public AescStr( string start )
        {
            // Plus one just in case.
            characters.Capacity = start.Length + 1;
            foreach( char c in start )
            {
                characters.Add( c );
            }
        }
        public string RealString()
        {
            string tempStr = "";

            foreach( char c in characters )
            {
                tempStr += c;
            }

            return( tempStr );
        }
        public void Set( int index,char updated )
        {
            characters[index] = updated;
        }
        public char Get( int index )
        {
            return( characters[index] );
        }
        public bool IsEqualTo( AescStr other )
        {
            if( characters.Count != other.characters.Count )
            {
                return( false );
            }
            else
            {
                for( int i = 0; i < characters.Count; ++i )
                {
                    if( characters[i] != other.characters[i] )
                    {
                        return( false );
                    }
                }

                return( true );
            }
        }
    }
}
