import type IKnight from "@/interface/IKnight";

export async function obterHerois() {
    let knights = new Array<IKnight>();
    const data = await fetch('http://localhost:5171/api/knights');

    if (data) {
        knights = await data.json() as IKnight[];
    }

    return knights;
}
