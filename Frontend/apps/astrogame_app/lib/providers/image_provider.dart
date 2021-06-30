import 'package:astrogame_app/communications/repositories/image_respository.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_memory_cache/flutter_memory_cache.dart';
import 'package:injectable/injectable.dart';
import 'package:synchronized/synchronized.dart';

@singleton
class BuildingImageProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  ImageRepository _imageRepository;

  BuildingImageProvider(this._imageRepository);

  Future<ImageProvider> get(String assetName) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(assetName);

      if (values != null) {
        return values;
      }

      var response = await _imageRepository.getBuildingImageAsync(assetName);

      if (response.hasError) {
        throw Exception('Failed to load image $assetName');
      }

      _memoryCache.put(assetName, response.data);
      return response.data;
    });
  }
}

@singleton
class ResearchImageProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  ImageRepository _imageRepository;

  ResearchImageProvider(this._imageRepository);

  Future<ImageProvider> get(String assetName) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(assetName);

      if (values != null) {
        return values;
      }

      var response = await _imageRepository.getResearchImageAsync(assetName);

      if (response.hasError) {
        throw Exception('Failed to load image $assetName');
      }

      _memoryCache.put(assetName, response.data);
      return response.data;
    });
  }
}

@singleton
class SpeciesImageProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  ImageRepository _imageRepository;

  SpeciesImageProvider(this._imageRepository);

  Future<ImageProvider> get(String assetName) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(assetName);

      if (values != null) {
        return values;
      }

      var response = await _imageRepository.getSpeciesImageAsync(assetName);

      if (response.hasError) {
        throw Exception('Failed to load image $assetName');
      }

      _memoryCache.put(assetName, response.data);
      return response.data;
    });
  }
}

@singleton
class StellarObjectImageProvider {
  var _memoryCache = new MemoryCache(ttl: 60 * 60);
  var _lock = new Lock();

  ImageRepository _imageRepository;

  StellarObjectImageProvider(this._imageRepository);

  Future<ImageProvider> get(String assetName) async {
    return await _lock.synchronized(() async {
      var values = _memoryCache.get(assetName);

      if (values != null) {
        return values;
      }

      var response = await _imageRepository.getStellarObjectImageAsync(assetName);

      if (response.hasError) {
        throw Exception('Failed to load image $assetName');
      }

      _memoryCache.put(assetName, response.data);
      return response.data;
    });
  }
}
