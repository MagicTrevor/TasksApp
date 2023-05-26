import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { TaskItem } from "../models/task-item";

@Injectable()
export class ApiHttpClientService {
    constructor(private http: HttpClient) { }

    public getTaskItems() {
        return this.http.get<TaskItem[]>("http://localhost:8080/api/taskitems/");
    }

    public create(item: TaskItem) {
        return this.http.post<TaskItem>("http://localhost:8080/api/taskitems/", item);
    }

    public updateDescription(id: string, description: string) {
        return this.http.post<TaskItem>(`http://localhost:8080/api/taskitems/${id}/description?description=$(description)`, null);
    }

    public complete(id: string) {
        return this.http.post<TaskItem>(`http://localhost:8080/api/taskitems/${id}/complete`, null);
    }
}