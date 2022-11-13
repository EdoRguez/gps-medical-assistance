import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MapSearchLocation } from '../../interfaces/mapSearchLocation.interface';

@Injectable({
    providedIn: 'root',
})
export class MapSearchLocationService {
    private baseUrl: string = environment.API_MAP_SEARCH_LOCATION;

    constructor(private _http: HttpClient) {}

    searchLocationByQuery(
        searchQuery: string
    ): Observable<MapSearchLocation[]> {
        const options = {
            params: new HttpParams()
                .set('addressdetails', 1)
                .set('q', searchQuery)
                .set('format', 'json')
                .set('limit', 5)
                .set('countrycodes', 'VE')
                .set('state', 'caracas'),
        };

        return this._http.get<MapSearchLocation[]>(`${this.baseUrl}`, options);
    }

    searchLocationByCoordinates(
        lat: number,
        lon: number
    ): Observable<MapSearchLocation> {
        const options = {
            params: new HttpParams()
                .set('q', `${lat},${lon}`)
                .set('polygon_geojson', 1)
                .set('format', 'json'),
        };

        return this._http
            .get<MapSearchLocation[]>(`${this.baseUrl}`, options)
            .pipe(map((x: MapSearchLocation[]) => x[0]));
    }
}
