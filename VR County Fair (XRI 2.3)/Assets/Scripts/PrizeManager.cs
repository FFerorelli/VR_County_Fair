using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    public static PrizeManager Instance;
    //public event Action<int> ScoreUpdated;

    [SerializeField] private int ringTossPrizeScore = 20;
    [SerializeField] private GameObject ringTossTicketPrefab;
    [SerializeField] private Transform ringTossTicketSpawnPoint;
    [SerializeField] private bool HasSpawnedRingTossTicket;

    private RingTossBoothService _ringTossBoothService;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _ringTossBoothService = FindAnyObjectByType<RingTossBoothService>();
        _ringTossBoothService.ScoreUpdated += HandleRingTossScoreChange;
    }

    private void OnDestroy()
    {
        _ringTossBoothService.ScoreUpdated -= HandleRingTossScoreChange;
    }

    private void HandleRingTossScoreChange(int newScore)
    {
        
        if (newScore >= ringTossPrizeScore && !HasSpawnedRingTossTicket)
        {
            
            Instantiate(ringTossTicketPrefab, ringTossTicketSpawnPoint.position, ringTossTicketSpawnPoint.rotation);
            HasSpawnedRingTossTicket = true;
        }
    }
}
