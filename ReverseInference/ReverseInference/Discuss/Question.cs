public class Question
{
    public string QuestionString;
    public string FeatureOne;
    public string FeatureTwo;
    public string Condition;
    public float Chance;

    public Question(string featureOne, string featureTwo, string condition, bool isQuestion = false, string question = "null")
    {
        FeatureOne = featureOne;
        FeatureTwo = featureTwo;
        Condition = condition;

        QuestionString = question;
    }
}
