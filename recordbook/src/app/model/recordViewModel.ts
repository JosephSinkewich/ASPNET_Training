import { EventModel } from './eventModel';

export class RecordViewModel {
    
    public Id: number;
    public Name: string;
    public CreateDate: Date;
    public Description: string;
    public Category: string;
    public PicturePath? :string;
    public Events: EventModel[];
}