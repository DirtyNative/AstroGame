// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'resource_snapshot.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ResourceSnapshot _$ResourceSnapshotFromJson(Map<String, dynamic> json) {
  return ResourceSnapshot()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..stellarObjectId =
        const GuidConverter().fromJson(json['stellarObjectId'] as String)
    ..snapshotTime = DateTime.parse(json['snapshotTime'] as String)
    ..storedResources = (json['storedResources'] as List<dynamic>)
        .map((e) => StoredResource.fromJson(e as Map<String, dynamic>))
        .toList();
}

Map<String, dynamic> _$ResourceSnapshotToJson(ResourceSnapshot instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'stellarObjectId': const GuidConverter().toJson(instance.stellarObjectId),
      'snapshotTime': instance.snapshotTime.toIso8601String(),
      'storedResources': instance.storedResources,
    };
