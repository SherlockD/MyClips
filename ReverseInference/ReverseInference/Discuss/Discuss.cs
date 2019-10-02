namespace ReverseInference.DiscussNode
{
    public class Discuss
    {
        public string ObjectName;
        public string Feature;
        public string Condition;

        public Discuss(string objectName, string feature, string condition)
        {
            ObjectName = objectName;
            Feature = feature;
            Condition = condition;
        }
    }
}