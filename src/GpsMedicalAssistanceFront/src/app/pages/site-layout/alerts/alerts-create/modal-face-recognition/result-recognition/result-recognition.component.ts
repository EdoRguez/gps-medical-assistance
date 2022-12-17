import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/shared/interfaces/user.interface';

@Component({
  selector: 'app-result-recognition',
  templateUrl: './result-recognition.component.html',
  styleUrls: ['./result-recognition.component.scss']
})
export class ResultRecognitionComponent implements OnInit {
  @Output() resultStatus = new EventEmitter<number>();
  @Input() user$!: Observable<User | null>;
  user: User | null = null;

  constructor() { }

  ngOnInit(): void {
    this.user$.subscribe({
      next: (user: User | null) => {
        this.user = user;
      }
    });
  }

  onProcessResultStatus(statusId: number): void {
    this.user = null;
    this.resultStatus.next(statusId);
  }

}
