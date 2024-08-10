namespace AlgoTown.Core
{
    public abstract class AbstractTown
    {
        // Get the name from the type
        public string TownName
        {
            get
            {
                return GetType().Name;
            }
        }

        /// <summary>
        /// X pivot of the ASCII art in characters from left to right
        /// </summary>
        public int ASCIIArtPivotX { get; protected set;} = 1;

        /// <summary>
        /// Y pivot of the ASCII art in characters from top to bottom
        /// </summary>
        public int ASCIIArtPivotY { get; protected set;} = 1;

        public AbstractTown()
        {
        }

        /// <summary>
        /// Return the ASCII art for the town.
        /// Override for custom ASCII art but keep the size limited to <br/> 
        /// Width: 30 characters<br/>
        /// Height: 10 characters
        /// </summary>
        public virtual string GetASCIIArt()
        {
            // This ASCII art example is 22 characters long so the PivotX property should be set to 11 to center it.
            // Its height is 8 characters high so the PivotY property should be set to 4 to center it.

            ASCIIArtPivotX = 11;
            ASCIIArtPivotY = 4;

            // An important note is that when using verbatim string literals (e.g. @"")
            // you shouldn't format the string to your document otherwise unwanted tabs will be inserted
            // so make sure the string is all the way to the left of your document.
            
            /*
@"
                ______________
               // /// |\\ \ \\\
             //_///_//||_\\\_\_\\
            / /// // //|\ \\ \ \\\      Not OK!
            |         __         |
            |        /  \        |
            |________|__|________|
";


@"
    ______________
   // /// |\\ \ \\\
 //_///_//||_\\\_\_\\
/ /// // //|\ \\ \ \\\      OK!
|         __         |
|        /  \        |
|________|__|________|
";
             */

            return
@"
    ______________
   // /// |\\ \ \\\
 //_///_//||_\\\_\_\\
/ /// // //|\ \\ \ \\\
|         __         |
|        /  \        |
|________|__|________|
";
        }

        /// <summary>
        /// This method returns a <see cref="TownActions"/> based on 
        /// the information given from the previous turn
        /// </summary>
        public abstract TownActions PerformAction(TurnInfo info);

    }
}
