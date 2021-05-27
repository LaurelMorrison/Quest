namespace Quest
{
    public class Hat
    {

        public int ShininessLevel { get; set; }

        public string ShininessDescription
        {
            get
            {
                if (ShininessLevel < 2)
                {
                    return "dull";
                }
                if (ShininessLevel >= 2 && ShininessLevel <= 5)
                {
                    return "noticeable";
                }
                if (ShininessLevel >= 6 && ShininessLevel <= 9)
                {
                    return "bright";
                }
                else
                {
                    return "blinding";
                }
            }
        }
    }
}