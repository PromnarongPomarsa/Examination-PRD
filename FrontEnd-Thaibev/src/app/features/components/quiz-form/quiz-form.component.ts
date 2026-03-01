import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

// PrimeNG imports
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { RadioButtonModule } from 'primeng/radiobutton';
import { CardModule } from 'primeng/card';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';

// Import the component
import { QuizAddComponent } from '../quiz-add/quiz-add.component';

//import model
import { ResponseDto } from '../../../models/ResponseDto.modal';
import { MsgDto } from '../../../models/MsgDto.modal';
import { ListQuestionDto } from '../../../models/ListQuestionDto';

//service api
import { ApiService } from '../../../services/api.service';

@Component({
  selector: 'app-quiz-form',
  standalone: true,
  imports: [
    CommonModule,
    RadioButtonModule,
    ButtonModule,
    FormsModule,
    CardModule,
  ],
  templateUrl: './quiz-form.component.html',
  styleUrl: './quiz-form.component.css',
  providers: []
})
export class QuizFormComponent implements OnInit {
  // open modal
  ref: DynamicDialogRef | null = null;
  public dialogService = inject(DialogService);

  // variables for quiz form
  q1: string = '';
  q2: string = '';
  displayItems = false;
  nonItems: string = "";
  questions: ListQuestionDto[] = [];
  // questions: any[] = [
  //   {
  //     id: 1,
  //     text: 'ข้อใดกล่าวถูกต้อง',
  //     options: ['3', '5', '9', '11'],
  //     answer: null
  //   },
  //   {
  //     id: 3,
  //     text: 'X + 2 = 4 จงหาค่า X',
  //     options: ['1', '2', '3', '4'],
  //     answer: null
  //   }
  // ];
  constructor(
    private _apiService: ApiService,
    router: Router) { }

  ngOnInit() {
    this.getMsg();
    this.getQuestionsData();
  }

  getQuestionsData() {
    this._apiService.getQuestions().subscribe({
      next: (response: ResponseDto<ListQuestionDto[]>) => {
        if (response.isSuccess == true) {
          this.questions = response.result;
        }
          console.log("questions: ", this.questions);
      },
      error: (error) => {
        console.log("Error getQuestionData: ",error)
      }
    })
  }

  getMsg() {
    this._apiService.getAllMsg().subscribe({
      next: (response: ResponseDto<MsgDto[]>) => {
        if (response.isSuccess == true) {
          this.nonItems = response.result.find((msg: MsgDto) => msg.msgCode === 'T001')?.msgDesc || "";
        }
      },
      error: (error) => {
        console.log("Error getMsg: ",error);
      }
    });
  }

  addQuestion() {
    this.ref = this.dialogService.open(QuizAddComponent, {
      header: 'IT 08-2',
      width: '50%',
      modal: true,
      closable: true,
      styleClass: 'quiz-page'
    });

    this.ref?.onClose.subscribe((result: ResponseDto<any>)=> {
      this.getQuestionsData();
    });
  }

  deleteQuestion(id: number) {
    // When you remove an item, Angular's index in the HTML 
    // will handle the "Running Number" update automatically
    this.questions = this.questions.filter(q => q.id !== id);
  }

  ngOnDestroy() {
    if (this.ref) {
      this.ref.close();
    }
  }

}
