using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UniRx;


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

	[SerializeField] private Button _workButton, _dataClearButton;
	[SerializeField] private Text
		_moneyLabel,
		_autoWorkLabel,
		_employeesCountLabel,
		_productivityLabel;
	
	[SerializeField] private Const.View
		_currentView = Const.View.Close,
		_lastView = Const.View.Purchase;
	
	private static User User { get { return GameManager.instance.User; } }
	
//	[SerializeField] private Button openButton;
	private bool isMoving = false;

	public void Setup()
	{
		_mentorPurchaseView.SetCells();
		_mentorTrainingView.SetCells();

//		openButton.onClick.AddListener(() =>
//		{
//			openButton.gameObject.SetActive(false);
//			ChangeView(lastView);
//		});

		UpdateView();
		
		_workButton.onClick.AddListener(() =>
		{
			var power = User.Characters.Sum(c => c.Power);
			if (power == 0) power = 1;
			User.AddMoney(power);
			UpdateView();
		});
		
		_dataClearButton.onClick.AddListener(() => 
		{
			PlayerPrefs.DeleteAll();
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
		});

		User.Money.Subscribe(_ => { UpdateView(); });
	}
	
	public void UpdateView()
	{
		_moneyLabel.text = string.Format("¥{0:#,0}", User.Money);
		_employeesCountLabel.text = string.Format("{0:#,0}人", User.Characters.Count);
		_productivityLabel.text = string.Format("¥{0:#,0}", User.ProductivityPerTap);
	}

	public void ChangeView(Const.View nextView)
	{
		if (_currentView == nextView) return;
		_lastView = _currentView;
		_currentView = nextView;
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
		var target = (_currentView == Const.View.Close) ? _closePoint : _openPoint;
		_userInfoPanel.position = target.transform.position;
	}
}
