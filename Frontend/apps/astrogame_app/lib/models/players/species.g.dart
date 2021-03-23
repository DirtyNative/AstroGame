// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'species.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Species _$SpeciesFromJson(Map<String, dynamic> json) {
  return Species()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..assetName = json['assetName'] as String;
}

Map<String, dynamic> _$SpeciesToJson(Species instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'assetName': instance.assetName,
    };
