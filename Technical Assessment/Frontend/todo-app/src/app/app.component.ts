import { Component, ViewChild } from '@angular/core';
import { TaskListComponent } from './components/task-list/task-list.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @ViewChild('taskList') taskList!: TaskListComponent;

  onTaskAdded() {
    this.taskList.loadTasks(); // 👈 refresh the list
  }
}
