import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task, TaskCreate } from '../models/task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'https://localhost:7241/api/tasks'; // adjust port if needed

  constructor(private http: HttpClient) {}

  getRecentTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.apiUrl);
  }

  createTask(task: TaskCreate): Observable<Task> {
    return this.http.post<Task>(this.apiUrl, task);
  }

  markAsDone(id: number): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${id}/done`, {});
  }
}
