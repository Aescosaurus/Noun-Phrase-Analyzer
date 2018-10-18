using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
///     Enter a list of nouns and this removes exact copies
///      and alphabetizes them.
///      Make sure you have only one noun on each line!
/// </summary>
namespace NounPhraseAnalyzer
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.Write( "Enter file name of noun list: " );
            AescStr filename = new AescStr( Console.ReadLine() );
            Console.WriteLine();
            StreamReader input = null;

            try
            {
                input = new StreamReader( filename.RealString() );

                var nouns = GetNouns( input );

                Console.WriteLine( "Operations in progress.  This might take a while..." );
                RemoveDupes( nouns );
                CapitalizeFirst( nouns );
                SortList( nouns );

                StreamWriter output = null;
                try
                {
                    output = new StreamWriter( "Sorted.txt" );

                    foreach( AescStr str in nouns )
                    {
                        output.WriteLine( str.RealString() );
                    }
                }
                catch( IOException e )
                {
                    Console.WriteLine( "Something went wrong! " + e.Message );
                }
                finally
                {
                    if( output != null ) output.Close();
                }
                Console.WriteLine( "We're all done here, your nouns are now sorted.  Have a nice day!" );
            }
            catch( IOException e )
            {
                Console.WriteLine( "We have errors captain! " + e.Message );
            }
            finally
            {
                if( input != null ) input.Close();
            }

            Console.ReadLine();
        }
        static List<AescStr> GetNouns( StreamReader fileReader )
        {
            var nouns = new List<AescStr>();

            while( true )
            {
                nouns.Add( new AescStr( fileReader.ReadLine() ) );

                if( fileReader.EndOfStream ) break;
            }

            return( nouns );
        }
        /// <summary>
        ///     Removes items that are exactly identical.
        /// </summary>
        /// <param name="origList">List of nouns.</param>
        static void RemoveDupes( List<AescStr> origList )
        {
            for( int i = 0; i < origList.Count; ++i )
            {
                for( int j = 0; j < origList.Count; ++j )
                {
                    if( j != i &&
                        origList[i].IsEqualTo( origList[j] )
                        // ( origList[i].RealString().Contains( origList[j].RealString() ) ||
                        // origList[j].RealString().Contains( origList[i].RealString() ) )
                        )
                    {
                        origList.RemoveAt( i );
                        --i;
                        if( i < 0 ) i = 0;
                    }
                }
            }
        }
        /// <summary>
        ///     Capitalize the first letter of each item so
        ///      sorting method will finally like me.
        /// </summary>
        /// <param name="uncapitalized">
        ///     List where all the first letters in all the
        ///      items might not be capitalized.
        /// </param>
        static void CapitalizeFirst( List<AescStr> uncapitalized )
        {
            foreach( AescStr s in uncapitalized )
            {
                s.Set( 0,s.Get( 0 ).ToString().ToUpper()[0] );
            }
        }
        /// <summary>
        ///     Sorts a list based on first letter.  Make
        ///      all the first letters capital first pls.
        /// </summary>
        /// <param name="unsorted">
        ///     Unsorted list where all the first letters
        ///      of each item are capitalized.
        /// </param>
        static void SortList( List<AescStr> unsorted )
        {
             for( int i = 0; i < unsorted.Count; ++i )
            {
                for( int j = 0; j < unsorted.Count - i - 1; ++j )
                {
                    // if( unsorted[j].Get( 0 ) > unsorted[j + 1].Get( 0 ) )
                    if( String.Compare( unsorted[j].RealString(),
                        unsorted[j + 1].RealString() ) > 0 )
                    {
                        Swap( ref unsorted,j,j + 1 );
                    }
                }
            }
        }
        static void Swap( ref List<AescStr> list,int spot1,int spot2 )
        {
            var temp = list[spot1];
            list[spot1] = list[spot2];
            list[spot2] = temp;
        }
    }
}
