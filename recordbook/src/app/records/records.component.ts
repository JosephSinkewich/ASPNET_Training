import { Component, OnInit } from '@angular/core';
import { RecordService } from '../services/recordService';
import { EventService } from '../services/eventService';
import { CategoryService } from '../services/categoryService';
import { EventModel } from '../model/EventModel';
import { RecordViewModel } from '../model/recordViewModel';
import { Record } from '../model/record';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.css']
})
export class RecordsComponent implements OnInit {

  private records: Record[];

  constructor(private recordService: RecordService,
    private eventService: EventService,
    private categoryService: CategoryService) { }

  ngOnInit() {
    this.recordService.getAllRecords().subscribe((data: Record[]) => this.records = data);
  }

  onAdd() {
    //go to edit record page
  }

  onEdit(id: number) {
    //go to edit record page
  }

  onDelete(id: number) {
    this.recordService.deleteRecord(id).subscribe();
  }

  getEventsByRecordId(id: number): EventModel[] {
    console.log("it works!");
    let result: EventModel[];
    this.eventService.getEventByRecordId(id).subscribe((data: EventModel[]) => result = data);
    result.forEach( function(eve)
    {
      console.log(eve.Name);
    });
    return result;
  }
}
