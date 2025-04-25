using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemyManager : MonoBehaviour
{
    public Element[] elements;
    public GameObject elementButtonPrefab;
    public Transform elementsParent;
    public Image resultImage;
    private List<Element> selectedElements = new List<Element>();

    void Start()
    {
        foreach (Element element in elements)
        {
            GameObject button = Instantiate(elementButtonPrefab, elementsParent);
            button.GetComponentInChildren<Text>().text = element.elementName;
            button.GetComponent<Image>().sprite = element.icon;
            button.GetComponent<Button>().onClick.AddListener(() => OnElementClicked(element));
        }
    }

    public void OnElementClicked(Element element)
    {
        if (selectedElements.Count < 2)
        {
            selectedElements.Add(element);
            if (selectedElements.Count == 2)
            {
                CombineElements();
            }
        }
    }

    private void CombineElements()
    {
        Element element1 = selectedElements[0];
        Element element2 = selectedElements[1];
        
        foreach (Element combElement in element1.combinableWith)
        {
            if (combElement == element2)
            {
                Element result = element1.resultElement;
                resultImage.sprite = result.icon;
                Debug.Log("Combined " + element1.elementName + " and " + element2.elementName + " to create " + result.elementName);
                selectedElements.Clear();
                return;
            }
        }
        
        Debug.Log("Combination failed.");
        selectedElements.Clear();
    }
}