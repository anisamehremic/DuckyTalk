# This files contains your custom actions which can be used to run
# custom Python code.
#
# See this guide on how to implement these action:
# https://rasa.com/docs/rasa/custom-actions


# This is a simple example for a custom action which utters "Hello World!"

from typing import Any, Text, Dict, List

from rasa_sdk import Action, Tracker
from rasa_sdk.executor import CollectingDispatcher
from rasa_sdk.events import SlotSet


import pyodbc


class ActionHelloWorld(Action):

    def name(self) -> Text:
        return "action_hello_world"

    def run(self, dispatcher: CollectingDispatcher,
            tracker: Tracker,
            domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:
        print("im from custom action!")
        print((tracker.latest_message)['text'])
        
        dispatcher.utter_message(text="Hello World from custom action!" + tracker.sender_id)


        conn = pyodbc.connect("DRIVER={ODBC Driver 17 for SQL Server};SERVER=%s;DATABASE=%s;UID=%s;PWD=%s"
                            % ("host.docker.internal, 1434", "eProdaja", "sa", "QWEasd123!"))

        cur = conn.cursor()
        db_cmd = "SELECT DobavljacId, Naziv FROM [dbo].[Dobavljaci]"
        res = cur.execute(db_cmd)
        # Do something with your result set, for example print out all the results:
        for r in res:
            dispatcher.utter_message(text="Dobavljac: " + str(r[0]) + r[1])

        return [SlotSet("email", (tracker.latest_message)['text'])]


class ActionSetInterestForJava(Action):

    def name(self) -> Text:
        return "action_interest_java"

    def run(self, dispatcher: CollectingDispatcher,
            tracker: Tracker,
            domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:

        return [SlotSet("interest_java", (tracker.latest_message)['text'])]

class ActionSetInterestForCSharp(Action):

    def name(self) -> Text:
        return "action_interest_csharp"

    def run(self, dispatcher: CollectingDispatcher,
            tracker: Tracker,
            domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:
       
       
        return [SlotSet("interest_csharp", (tracker.latest_message)['text'])]


class ActionTellDevJoke(Action):

    def name(self) -> Text:
        return "action_tell_dev_joke"

    def run(self, dispatcher: CollectingDispatcher,
            tracker: Tracker,
            domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:
        
        #this can be queried from DB and randomly popped up, or some some REST API
        dispatcher.utter_message(text="A SQL query walks into a bar and sees two tables. He walks up to them and says 'Can I join you?'")

        return []


class ActionTellDadJoke(Action):

    def name(self) -> Text:
        return "action_tell_dad_joke"

    def run(self, dispatcher: CollectingDispatcher,
            tracker: Tracker,
            domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:
        
        
        dispatcher.utter_message(text="I don't trust stairs. They're always up to something.")

        return []