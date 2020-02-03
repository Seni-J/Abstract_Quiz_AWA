﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractQuizzStructure;

/**
 * HerokuApi does: 
 *  - Define which model it is attached to (here it is HerokuApiModel)
 *  - Configure/Set how the code should get data
 *      --> Defines the link, if it should have a token to get data
 */
public class HerokuApi : ApiManager
{
    public HerokuApiModel herokuApiModel;

    public HerokuApi()
    {
        base.SetChild(this);
        // Set the configuration needed to get data for Quizzes/Questions/Ansers. 
        base.rootApiUrl = "https://awa-quizz.herokuapp.com/api";
        base.apiQuizzesUrl = rootApiUrl+ "/quizzes";
        base.apiQuestionsUrl = rootApiUrl+ "/quizzes/{quizzId}";
        base.apiAnswersUrl = rootApiUrl+ "/quizzes/{quizzId}";

        // Set the configuration needed for the API token.
        base.hasToHaveTokenForApi = true;
        base.hasToLoginToGetToken = false;
        base.tokenHttpEmplacement = TokenHttpEmplacement.Everywhere; // Put the token everywhere where we can (url/header/body)
        base.apiKeyParamName = "quizz-token"; // Define the name of the parameter used when token has to be sent over http (api_token={TOKEN} be it in url/header/body)
        base.apiToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VybmFtZSI6Imd1ZXN0IiwicGFzc3dvcmQiOiIkcGJrZGYyLXNoYTI1NiQyMDAwMCRjNjRWd3RnN0IuQThKeVJrN1AzL1h3JG9BRDloUnVEQTVkWVpKR1Y2cDNpdDBzYVFqdlFBemFZbi9wNW1kSGRDbDQifQ.P-KfTO8nq5oQNC_bIAY5VKOeNLyNbGE-gGrf0oIKQjc";
    }

    public override Quizzes SerializeQuizzes(string jsonData)
    {
        return (Quizzes)JsonUtility.FromJson<HerokuApiModel.QuizzesInAPI>(jsonData);
    }

    public override Questions SerializeQuestions(string jsonData)
    {
        return (Questions)JsonUtility.FromJson<HerokuApiModel.QuestionsInAPI>(jsonData);
    }

    public override Answers SerializeAnswers(string jsonData)
    {
        return (Answers)JsonUtility.FromJson<HerokuApiModel.AnswersInAPI>(jsonData);
    }
}
