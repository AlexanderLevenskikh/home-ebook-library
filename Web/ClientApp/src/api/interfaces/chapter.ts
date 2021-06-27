import { IChapterListDto, IGetChaptersRequestDto } from 'root/api/dto/chapter';

export interface IChapterApi {
    getChapters(request: IGetChaptersRequestDto): Promise<IChapterListDto>;
}
