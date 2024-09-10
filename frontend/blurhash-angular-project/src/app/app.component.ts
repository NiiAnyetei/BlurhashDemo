import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiData } from 'src/models/models';

const apiUrl = "https://localhost:5001/api/Images";

type LoadingState = "Loading" | "Loaded" | "Error";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'blurhash-angular-project';
  error = null;
  status: LoadingState = "Loading";
  apiData: ApiData = {
    uploadedImages: [],
    uploadedImagesCount: 0
  }

  constructor(private httpClient: HttpClient) {
  }
  
  ngOnInit(){
    return this.httpClient.get<ApiData>(apiUrl)
    .subscribe({
      next: (response) => {
        this.apiData = response;
        this.status = 'Loaded';
      },
      error: (err) => {
        this.error = err;
        this.status = 'Error';
      },
    });
  }
}