import { KoaServer } from "./tools/koa-server/koa-server";
import { routes } from "./tools/routes/routes";

export const koaServer = new KoaServer();
koaServer.initRoutes(routes);