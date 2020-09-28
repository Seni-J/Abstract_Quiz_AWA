using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractQuizzStructure;

public class KwizApiModel : MonoBehaviour
{
    [Serializable]
    public class QuizzesInAPI : Quizzes
    {
        public List<QuizzInAPI> quizzes;

        public override void MapAPIValuesToAbstractClass()
        {
            foreach(QuizzInAPI quizzdata in this.quizzes)
            {
                quizzdata.MapAPIValuesToAbstractClass();
                base.AddQuizz(quizzdata);
            }
        }
    }

    [Serializable]
    public class QuizzInAPI : Quizz
    {
        public int id;
        public string title;
        public string description;

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetQuizzId(id);
            base.SetQuizzTitle(title);
        }
    }
    [Serializable]
    public class QuestionsInAPI : Questions
    {
        public List<QuestionInAPI> questions;

        public override void MapAPIValuesToAbstractClass()
        {
            foreach (QuestionInAPI questionData in this.questions)
            {
                questionData.MapAPIValuesToAbstractClass();
                base.AddQuestion(questionData);
            }
        }
    }

    [Serializable]
    public class QuestionInAPI : Question
    {
        public int id;
        public int quizzId;
        public string question;

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetQuestionid(id);
            base.SetQuestionText(question);
        }
    }

    [Serializable]
    public class AnswersInAPI : Answers
    {
        public List<AnswerInAPI> answers;

        public override void MapAPIValuesToAbstractClass()
        {
            foreach (AnswerInAPI answerData in this.answers)
            {
                answerData.MapAPIValuesToAbstractClass(); // Map values
                base.AddAnswer(answerData);
            }
        }
    }

    [Serializable]
    public class AnswerInAPI : Answer
    {
        public int id; 
        public int questionId;
        public int quizzId;
        public string answer;
        public bool rightAnswer;
        

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetDataToShowAsPossibleAnswer(answer);
            base.SetIsCorrectAnswer(rightAnswer);
        }
    }
}
