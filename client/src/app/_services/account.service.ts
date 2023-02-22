import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

// เพิ่ม provider เข้าไปใน root อัตโนมัติ
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl: string = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(`${this.baseUrl}account/login`, model).pipe(
      map((res) => {
        const user = res;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user)) // แปรง JSON Object เป็น string
        }
      })
    );
  }
}
