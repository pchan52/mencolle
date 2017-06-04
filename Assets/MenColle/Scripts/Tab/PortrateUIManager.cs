using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class PortrateUIManager : SingletonMonoBehaviour<PortrateUIManager>
{

	[SerializeField] private MentorPurchaseView _mentorPurchaseView;
	[SerializeField] private MentorTrainingView _mentorTrainingView;
	[SerializeField] private Transform _userInfoPanel;
	[SerializeField] private Image _mainPanel;
	public MentorPurchaseView MentorPurchaseView { get { return _mentorPurchaseView; } }
	public MentorTrainingView MentorTrainingView { get { return _mentorTrainingView; } }
	public Transform UserInfoPanel {
		get { return _userInfoPanel; }
	}

	public Image MainPanel {
		get { return _mainPanel; }
	}

	[SerializeField] private Text
		_moneyLabel,
		_autoWorkLabel,
		_employeesCountLabel,
		_productivityLabel;
	
	[SerializeField] private Const.View
		currentView = Const.View.Close,
		lastView = Const.View.Purchase;
	
	[SerializeField] private Button openButton;
	private bool isMoving = false;

	public void Setup()
	{
		_mentorPurchaseView.SetCells();
		_mentorTrainingView.SetCells();

		openButton.onClick.AddListener(() =>
		{
			openButton.gameObject.SetActive(false);
			ChangeView(lastView);
		});
	}

	public void ChangeView(Const.View nextView)
	{
		if (currentView == nextView) return;
		lastView = currentView;
		currentView = nextView;
		isMoving = true;
		switch (nextView)
		{
			case Const.View.Purchase:
				_mainPanel.color = new Color(225f,225f,225f,100f);
				_mentorPurchaseView.gameObject.SetActive(true);
				_mentorTrainingView.gameObject.SetActive(false);
				break;
			case Const.View.Training:
				_mainPanel.color = new Color(225f,225f,225f,100f);
				_mentorPurchaseView.gameObject.SetActive(false);
				_mentorTrainingView.gameObject.SetActive(true);
				break;
			case Const.View.Close:
//				openButton.gameObject.SetActive(true);
				_mainPanel.color = new Color(225f,225f,225f,0f);
				_mentorPurchaseView.gameObject.SetActive(false);
				_mentorTrainingView.gameObject.SetActive(false);
				break;
		}
	}

	[SerializeField] private Transform
		_openPoint,
		_closePoint;
	
	private void Update () {
		if(!isMoving) return;
		var target = (currentView == Const.View.Close) ? _closePoint : _openPoint;
		_userInfoPanel.position = target.transform.position;
	}
}
