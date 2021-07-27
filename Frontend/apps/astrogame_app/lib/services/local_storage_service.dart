import 'dart:io';

import 'package:injectable/injectable.dart';
import 'package:localstorage/localstorage.dart';
import 'package:path_provider/path_provider.dart';

@singleton
class LocalStorageService {
  static const String _fileName = 'storage.json';

  late LocalStorage _localStorage;

// TODO: Set as init method for getIt
  Future initAsync() async {
    var file = await _localFile;

    await _createFile(file);

    _localStorage = new LocalStorage(_fileName);

    await _localStorage.ready;
  }

  Future<bool> containsAsync(String key) async {
    return (await readAsync(key) != null);
  }

  Future<T> readAsync<T>(String key) async {
    return await _localStorage.getItem(key);
  }

  Future writeAsync<T>(String key, T value) async {
    await _localStorage.setItem(key, value);
  }

  Future deleteAsync(String key) async {
    await _localStorage.deleteItem(key);
  }

  static Future<String> get _localPath async {
    final directory = await getApplicationSupportDirectory();
    return directory.path;
  }

  static Future<File> get _localFile async {
    final path = await _localPath;
    return File('$path/$_fileName');
  }

  static Future _createFile(File file) async {
    if (await file.exists() == false) {
      await file.create();
      await file.writeAsString('{}');
    }
  }
}
