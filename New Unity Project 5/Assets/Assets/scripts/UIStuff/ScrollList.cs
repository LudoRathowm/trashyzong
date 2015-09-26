using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[System.Serializable]
public class SkillButton {
	public string SkillName;
//	public Sprite icon;
	public string EnergyCost;
//	public Sprite icon;
//	public string type;
//	public string rarity;

	public Button.ButtonClickedEvent thingToDo;
}

public class ScrollList : MonoBehaviour {

	//public Text Textdunno;
	public GameObject sampleButton;
	//public List<SkillButton> myList = new List<SkillButton>();
	public Transform contentPanel;
	//public Button.ButtonClickedEvent thingToDo;
	// Use this for initialization
	void Start () { //change to act l8r
		//PopulateList();
	}
	public void DisplaySkills(){
		FlushOldButtons();
		transform.parent.gameObject.SetActive(true);
		PopulateList();
	}

	 void PopulateList (){
		//FlushOldButtons();

		List <muhSkills>	CurrentPlayerSkills;
		List <string> SkillNameCorrect = new List <string>();
		List <string> SkillCostCorrect = new List <string>();
		List <Button.ButtonClickedEvent> SkillMethodActivate = new List<Button.ButtonClickedEvent>(); 
	CurrentPlayerSkills = GameManager.instance.GetSkills();
		for (int i = 0;i<CurrentPlayerSkills.Count;i++){
			SkillNameCorrect.Add(CurrentPlayerSkills[i].ToString());
			SkillCostCorrect.Add (" Cost: "+Skill.FromListOfSkills(CurrentPlayerSkills[i]).EnergyCost.ToString());
			//Debug.Log(Skill.FromListOfSkills(CurrentPlayerSkills[i]).SkillEvent);
			SkillMethodActivate.Add (Skill.FromListOfSkills(CurrentPlayerSkills[i]).SkillEvent);
		//	Debug.Log(" Cost: "+Skill.FromListOfSkills(CurrentPlayerSkills[i]).EnergyCost.ToString());
		}
		SkillButton[] myButtonList = new SkillButton[CurrentPlayerSkills.Count];
		int kkk=0;
		foreach (var SkillButton in myButtonList){
			GameObject newButton = Instantiate (sampleButton)as GameObject;
			SampleButton button = newButton.GetComponent<SampleButton>();
			button.SkillName.text = SkillNameCorrect[kkk];
			button.EnergyCost.text = SkillCostCorrect[kkk];
			//Debug.Log("my Event: "+SkillMethodActivate[kkk]);
			//button.eventos =  SkillMethodActivate[kkk];

			button.button.onClick = SkillMethodActivate[kkk];

			newButton.transform.SetParent(contentPanel);
			kkk++;

		}
		}

public void FlushOldButtons (){
		Transform ContentPanel = transform.GetChild(0);
		if (ContentPanel.childCount > 0)
foreach (Transform child in ContentPanel)
			Destroy (child.gameObject);
	}

//		foreach (var Skill in myList){
////			Text Lel = Textdunno;
////			Lel.text = Skill.SkillName;
//			GameObject newButton = Instantiate ( sampleButton) as GameObject;
//			SampleButton button = newButton.GetComponent<SampleButton>();
//
//			button.SkillName.text = Skill.SkillName;
//			button.EnergyCost.text = Skill.EnergyCost;
//			newButton.transform.SetParent (contentPanel);
//
//
//		}
	}






