﻿namespace Yaringa.Services {
    public interface IDependencyService {
        T Get<T>() where T : class;
    }
}
