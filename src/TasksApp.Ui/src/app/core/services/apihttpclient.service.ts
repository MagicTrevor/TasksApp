import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { TaskItem } from "../models/task-item";
import { AuthService } from "src/app/shared/auth.service";
import { User } from "src/app/shared/user";

@Injectable()
export class ApiHttpClientService {
    constructor(private auth: AuthService, private http: HttpClient) {
        var user = new User();
        user.username = 'test';
        user.password = 'test';

        this.auth.login(user);
    }

    public getTaskItems() {
        return this.http.get<TaskItem[]>("http://localhost:8080/api/tasks/");
    }

    public create(item: TaskItem) {
        return this.http.post<TaskItem>("http://localhost:8080/api/tasks/", item);
    }

    public updateDescription(id: string, description: string) {
        return this.http.put<TaskItem>(`http://localhost:8080/api/tasks/${id}/description?description=$(description)`, null);
    }

    public complete(id: string) {
        return this.http.put<TaskItem>(`http://localhost:8080/api/tasks/${id}/complete`, null);
    }
}