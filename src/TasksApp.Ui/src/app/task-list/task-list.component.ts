import { Component, OnInit } from '@angular/core';
import { TaskItem } from '../core/models/task-item';
import { ApiHttpClientService } from '../core/services/apihttpclient.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})
export class TaskListComponent implements OnInit {
  public description = "";
  public taskItems = new Array<TaskItem>();

  constructor(private apiClient: ApiHttpClientService)
  {}

  ngOnInit(): void {
    this.refresh();
  }

  public refresh() {
    this.apiClient.getTaskItems().subscribe(data => this.taskItems = data);
  }

  public add(event: Event) {
    this.apiClient.create(new TaskItem(this.description)).subscribe(data => {
      this.description = "";
      this.refresh();
    });
  }
}
