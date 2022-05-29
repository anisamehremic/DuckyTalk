import { Component, OnInit } from '@angular/core';
import { StylesManager, Model, SurveyNG, Survey } from "survey-angular";

StylesManager.applyTheme("modern");

const surveyJson = {
  completedHtml: "<h4>You got <b>{correctAnswers}</b> out of <b>{questionCount}</b> correct answers. Work hard and play hard to get to the next level!</h4>",
  completedHtmlOnCondition: [{
    expression: "{correctAnswers} == 0",
    html: "<h4>Unfortunately, none of your answers are correct. You are not ready for the next level :(</h4>"
  }, {
    expression: "{correctAnswers} == {questionCount}",
    html: "<h4>Congratulations! You are a star! You have what it takes to be at this level!</h4>"
  }],
  pages: [
    {
      name: 'p1',
      elements: [
        {
          name: "q_num_tech",
          title: "How many technologies are you working with",
          type: "radiogroup",
          isRequired: true,
          choices: [
            {
              value: "0",
              text: "0"
            },
            {
              value: "1",
              text: "1"
            },
            {
              value: "2",
              text: "2"
            },
            {
              value: "3",
              text: "3"
            },
            {
              value: "4",
              text: "More..."
            }
          ]
        }
      ]
    },
    {
      name: 'p2',
      elements: [
        {
          name: "q_team_perform",
          title: "How well do you work in a team",
          type: "radiogroup",
          isRequired: true,
          correctAnswer: "1",
          choices: [
            {
              value: "0",
              text: "I don't work in a team"
            },
            {
              value: "1",
              text: "I get along with [almost] everyone"
            },
            {
              value: "2",
              text: "I prefer to not to work in a team"
            },
            {
              value: "3",
              text: "I hate working in a team"
            }
          ]
        }
      ]
    },
    {
      name: 'p3',
      elements: [
        {
          name: "q_team_preference",
          title: "Given the opportunity, what you would rather prefer",
          type: "radiogroup",
          isRequired: true,
          correctAnswer: "2",
          choices: [
            {
              value: "0",
              text: "Work alone"
            },
            {
              value: "1",
              text: "Work in a team"
            },
            {
              value: "2",
              text: "Work in a team where I have good mentor to guide me to the next level"
            }
          ]
        }
      ]
    },
    {
      name: 'p4',
      elements: [
        {
          name: "q_task_approach",
          title: "When you are given a task and you do not understand it, how do you approach it",
          type: "radiogroup",
          isRequired: true,
          correctAnswer: "1",
          choices: [
            {
              value: "0",
              text: "I don't start working on my task until everything is clear"
            },
            {
              value: "1",
              text: "I don't start working on my task until everything is clear and I hunt people until I get clarity"
            },
            {
              value: "2",
              text: "On every standup I raise awarness that I need clarification"
            },
            {
              value: "3",
              text: "I wait until someone comes to me and ask me why I don't to anything and explain to them that I don't understand my tasks"
            }
          ]
        }
      ]
    },
    {
      name: 'p5',
      elements: [
        {
          name: "q_mentality",
          title: "Are you",
          type: "radiogroup",
          isRequired: true,
          correctAnswer: "2",
          choices: [
            {
              value: "0",
              text: "Performer"
            },
            {
              value: "1",
              text: "Critic"
            },
            {
              value: "2",
              text: "A little bit of both but mostly performer"
            },
            {
              value: "3",
              text: "A little bit of both but mostly critic"
            }
          ]
        }
      ]
    }
  ]
};

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.scss']
})
export class SurveyComponent implements OnInit {

  constructor() { }

  alertResults(sender) {
    const results = JSON.stringify(sender.data);
    // alert(results);
  }

  ngOnInit(): void {
    const survey = new Model(surveyJson);
    survey.onComplete.add(this.alertResults);
    SurveyNG.render("surveyContainer", { model: survey });
  }

}
