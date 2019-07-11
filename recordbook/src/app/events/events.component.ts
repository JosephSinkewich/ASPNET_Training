import { Component, OnInit } from '@angular/core';
import { EventService } from "../services/eventService";
import { EventModel } from '../model/eventModel';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  private events: EventModel[];
  private newEvent: EventModel;

  constructor(private service: EventService) { }

  ngOnInit() {
    this.newEvent = new EventModel();
    this.service.getAllEvents().subscribe((data: EventModel[]) => this.events = data);
  }

  onAdd() {
    this.service.addEvent(this.newEvent).subscribe();
  }

  onDelete(id: number) {
    this.service.deleteEvent(id).subscribe();
  }

}
