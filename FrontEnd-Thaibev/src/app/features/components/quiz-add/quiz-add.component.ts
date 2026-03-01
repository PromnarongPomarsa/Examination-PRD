import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';

// import primeNG
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Button } from "primeng/button";
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';

//service api
import { ApiService } from '../../../services/api.service';

//import model
import { ListQuestionDto } from '../../../models/ListQuestionDto';
import { ResponseDto } from '../../../models/ResponseDto.modal';


@Component({
  selector: 'app-quiz-add',
  standalone: true,
  imports: [
    Button,
    ButtonModule,
    InputTextModule,
    FormsModule,
  ],
  templateUrl: './quiz-add.component.html',
  styleUrl: './quiz-add.component.css',
  providers: [DialogService, DynamicDialogRef]
})
export class QuizAddComponent implements OnInit {
  public ref = inject(DynamicDialogRef);
  public dialogService = inject(DialogService);

  questions: ListQuestionDto = {
    id: 0,
    question: '',
    choiceItems: [],
  };
  choiceItems: any[] = [];

  constructor(private _apiService: ApiService) { }

  ngOnInit(): void {
    this.defineValue();
  }

  defineValue() {
    this.choiceItems = [
      { reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 1', isCorrect: 'Y', createDate: new Date() },
      { reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 2', isCorrect: 'N', createDate: new Date() },
      { reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 3', isCorrect: 'N', createDate: new Date() },
      { reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 4', isCorrect: 'N', createDate: new Date() }
    ];
  }


  async saveData() {
    const valiData = await this.validation();

    if (!valiData) {
      return;
    }

    this.questions.choiceItems = this.choiceItems;
    this._apiService.saveQuestion(this.questions).subscribe({
      next: (response: ResponseDto<ListQuestionDto[]>) => {
        if (response.isSuccess == true) {
          this.ref?.close(response);
        }
      },
      error: (error) => {
        console.log("Error getQuestionData: ", error)
      }
    })
  }

  cancel() {
    this.ref?.close();
    console.log('cancel', this.ref);
  }

  async validation() {
    const validateQuestion = this.questions.question && this.questions.question.trim() !== '';
    const validateData = this.choiceItems.every(item => item.choiceText && item.choiceText.trim() !== '');

    if (!validateQuestion) {
      alert('กรุณากรอกคำถาม');
      return false;
    }
    return validateData;
  }

  ngOnDestroy() {
  }

}
