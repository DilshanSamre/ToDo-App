import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-task-create',
  templateUrl: './task-create.component.html',
  styleUrls: ['./task-create.component.scss']
})
export class TaskCreateComponent {
  @Output() taskAdded = new EventEmitter<void>();  // 👈 event

  taskForm = this.fb.group({
    title: ['', Validators.required],
    description: ['']
  });

  constructor(private fb: FormBuilder, private taskService: TaskService) {}

  onSubmit() {
    if (this.taskForm.valid) {
      const formValue = this.taskForm.value;
      if (formValue.title) {
        const taskCreate = {
          title: formValue.title,
          description: formValue.description || undefined
        };
        this.taskService.createTask(taskCreate).subscribe(() => {
          this.taskForm.reset();
          this.taskAdded.emit(); 
        });
      }
    }
  }
}
