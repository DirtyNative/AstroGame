// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'coordinates.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Coordinates _$CoordinatesFromJson(Map<String, dynamic> json) {
  return Coordinates(
    json['interStellar'] as int,
    json['solar'] as int,
    json['interPlanetar'] as int,
    json['interLunar'] as int,
    json['lunar'] as int,
  );
}

Map<String, dynamic> _$CoordinatesToJson(Coordinates instance) =>
    <String, dynamic>{
      'interStellar': instance.interStellar,
      'solar': instance.solar,
      'interPlanetar': instance.interPlanetar,
      'interLunar': instance.interLunar,
      'lunar': instance.lunar,
    };
