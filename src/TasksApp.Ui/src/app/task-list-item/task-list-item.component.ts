import { Component, OnInit, Input } from '@angular/core';
import { TaskItem } from '../core/models/task-item';
import { ApiHttpClientService } from '../core/services/apihttpclient.service';

@Component({
  selector: 'app-task-list-item',
  templateUrl: './task-list-item.component.html',
  styleUrls: ['./task-list-item.component.scss']
})
export class TaskListItemComponent implements OnInit {
  @Input() taskItem: TaskItem = new TaskItem();

  constructor(private apiClient: ApiHttpClientService) { }

  ngOnInit() { }

  public complete(checked: boolean) {
    if (checked) {
      this.apiClient.complete(this.taskItem.id).subscribe(data => {
        this.taskItem = data;
      });
    }
  }
}
