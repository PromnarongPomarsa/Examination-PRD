import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// import model
import { ListQuestionDto } from '../models/ListQuestionDto';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private http = inject(HttpClient);
    constructor() { }

    getAllMsg(): Observable<any> {
        return this.http.get(`/api/quiz/get-all-msg`);
    }

    getQuestions(): Observable<any> {
        return this.http.get(`/api/quiz/get-question`);
    }

    saveQuestion(data: ListQuestionDto): Observable<any> {
        return this.http.post(`/api/quiz/save-question`, data);
    }

}
