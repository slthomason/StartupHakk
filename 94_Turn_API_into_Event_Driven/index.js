import { EventBridgeClient, PutEventsCommand } from '@aws-sdk/client-eventbridge';
const events = new EventBridgeClient();
await events.send(new PutEventsCommand({
  Entries: [
    {
      Source: 'my-football-app',
      DetailType: 'Add Player Injury',
      Detail: JSON.stringify({
        playerId: "7",
        followUpDate: "2023-10-31",
        message: {
          type: "Ankle sprain",
          injuryDate: "2023-09-20"
        }
      })
    }
  ]
}));