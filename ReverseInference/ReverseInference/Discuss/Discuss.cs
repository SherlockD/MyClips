namespace ReverseInference.DiscussNode
{
    public class Discuss
    {
        public string Feature;
        public string Condition;
        public float Chance;

        public Discuss(string feature, string condition)
        {
            Feature = feature;
            Condition = condition;
        }
    }
}