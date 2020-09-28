using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;
using static AbstractQuizzStructure;

public class KwizApi : ApiManager
{
    public KwizApiModel kwizApiModel;
    public KwizApi()
    {
        base.SetChild(this); // Important, must be set so that ApiManager will call Serialize(Quizzes/Questions/Answers)..

        // Set the configuration needed to get data for Quizzes/Questions/Ansers. 
        base.rootApiUrl = "http://api.kwiz.mycpnv.ch/api";
        base.apiQuizzesUrl = rootApiUrl + "/quizzes";
        base.apiQuestionsUrl = rootApiUrl + "/quizzes/{quizzId}/questions";
        base.apiAnswersUrl = rootApiUrl + "/quizzes/{quizzId}/questions/{questionId}/answers";

        base.apiDataModelEndpointType = ApiDataModelEndpointType.EachModelHasAnEndpoint;

        // Set the configuration needed for the API token.
        base.hasToHaveTokenForApi = true;
        base.hasToLoginToGetToken = false;
        base.tokenHttpEmplacement = TokenHttpEmplacement.Everywhere; // Put the token everywhere where we can (url/header/body)
        base.apiKeyParamName = "api_token"; // Define the name of the parameter used when token has to be sent over http (api_token={TOKEN} be it in url/header/body)
        base.apiToken = "EBYeikGCyMz0mB9PL9kg3PzuoohZLTdd2Lj1Wsrxl0RFHtgnD1KsdFKHweTMOtsysH7GWfQe4AZh5tb6";
    }
    
    public override Quizzes SerializeQuizzes(string jsonData)
    {
        return (Quizzes)JsonUtility.FromJson<KwizApiModel.QuizzesInAPI>(jsonData);
    }

    public override Questions SerializeQuestions(string jsonData)
    {
        return (Questions)JsonUtility.FromJson<KwizApiModel.QuestionsInAPI>(jsonData);
    }

    public override Answers SerializeAnswers(string jsonData)
    {
        return (Answers)JsonUtility.FromJson<KwizApiModel.AnswersInAPI>(jsonData);
    }
}
